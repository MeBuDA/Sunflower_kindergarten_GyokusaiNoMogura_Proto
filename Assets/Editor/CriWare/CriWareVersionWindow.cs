/****************************************************************************
 *
 * Copyright (c) 2014 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;


public sealed class CriWareVersionWindow : EditorWindow
{
	private string		pluginsDirectory;
	private readonly string[][]	pluginBinaryFilenames	= {
		new string[]{"PC",      "PCx64",          "CRIWARE Monitor Unity(LE)", "x86_64/cri_ware_unity.dll"},
		new string[]{"PC",      "PCx86",          "CRIWARE Monitor Unity(LE)", "x86/cri_ware_unity.dll"},
		new string[]{"MacOSX",  "Mac_X86_64",     "CRIWARE Monitor Unity(LE)", "cri_ware_unity.bundle/Contents/MacOS/cri_ware_unity"},
		new string[]{"Android", "Android",        "CRIWARE Monitor Unity(LE)", "Android/libs/armeabi-v7a/libcri_ware_unity.so"},
		new string[]{"Android", "Android",        "CRIWARE Monitor Unity(LE)", "Android/libs/x86/libcri_ware_unity.so"},
		new string[]{"iOS",     "iOS_ARMv7",      "CRIWARE Monitor Unity(LE)", "iOS/libcri_ware_unity.a"},
		new string[]{"iOS",     "iOS_ARMv8_A64",  "CRIWARE Monitor Unity(LE)", "iOS/libcri_ware_unity.a"},
		new string[]{"iOS",     "iOS_SIM_X86",    "CRIWARE Monitor Unity(LE)", "iOS/libcri_ware_unity.a"},
		new string[]{"iOS",     "iOS_SIM_X86_64", "CRIWARE Monitor Unity(LE)", "iOS/libcri_ware_unity.a"},
    };
	
	private class ModuleInfo
	{
		public string name;
		public string target;
		public string version;
		public string buildDate;
		public string appendix;
	}
	
	private class PluginInfo
	{
		public string			platform;
		public string           target;
		public string           path;
		public ModuleInfo		info;
		public List<ModuleInfo>	moduleVersionInfos;
	}
	
	private List<PluginInfo>	pluginInfos;
	private string				detailVersionsString  = "";
	private string[]			detailVersionsStrings = {""};
	private Vector2				scrollPosition = new Vector2(0.0f, 0.0f);
	
	
	[MenuItem("Window/CRIWARE/Version Information", false, 200)]
	static void OpenWindow()
	{
		EditorWindow.GetWindow<CriWareVersionWindow>(false, "CRI Version");
	}
	
	
	private void OnEnable()
	{
		pluginsDirectory = System.IO.Path.Combine(Application.dataPath, "Plugins");
		Reload();
	}
	
	
	private void OnGUI()
	{
		EditorGUILayout.BeginVertical();
		{
			{
				EditorGUILayout.BeginHorizontal();
				if (GUILayout.Button("Copy To Clipboard", GUILayout.Width(180))) {
					EditorGUIUtility.systemCopyBuffer = PluginVersionsString();
					GUI.FocusControl("");
				}
				if (GUILayout.Button("Reload", GUILayout.Width(80))) {
					Reload();
					GUI.FocusControl("");
				}
				EditorGUILayout.EndHorizontal();
			}
			/* �X�N���v�g�o�[�W�����\�� */
			{
				EditorGUILayout.LabelField("Script Version");
				EditorGUI.indentLevel++;
				EditorGUILayout.LabelField("Ver." + CriWare.GetScriptVersionString());
				EditorGUI.indentLevel--;
			}
			EditorGUILayout.Space();
			/* �o�C�i���o�[�W�����\�� */
			{
				EditorGUILayout.LabelField("Binary Version");
			}
			EditorGUI.indentLevel++;
			/* �v���b�g�t�H�[���ʃv���O�C���o�C�i���o�[�W�����\�� */
			{
				EditorGUILayout.BeginVertical();
				GUILayoutOption platformColumnWidth  = GUILayout.Width(80);
				GUILayoutOption targetColumnWidth    = GUILayout.Width(120);
				GUILayoutOption versionColumnWidth   = GUILayout.Width(140);
				GUILayoutOption buildDateColumnWidth = GUILayout.Width(200);
				GUILayoutOption appendixColumnWidth  = GUILayout.Width(200);
				GUILayoutOption pathColumnWidth      = GUILayout.Width(400);
				if (pluginInfos != null) {
					foreach (var info in pluginInfos) {
						EditorGUILayout.BeginHorizontal();
						{
							if (GUILayout.Button(info.platform, EditorStyles.radioButton, platformColumnWidth)) {
								/* �\���̐����̂��ߕ\���\�ȕ������Ő؂�o�� */
								detailVersionsString  = ModuleInfosToAlignedString(info.moduleVersionInfos);
								detailVersionsStrings = SplitTextAreaMaxLength(detailVersionsString);
								scrollPosition = new Vector2(0.0f, 0.0f);
								GUI.FocusControl("");
							}

							if (info.info != null) {
								EditorGUILayout.LabelField((info.target ?? "--"), targetColumnWidth);
								EditorGUILayout.LabelField((info.info.version ?? "--"), versionColumnWidth);
								EditorGUILayout.LabelField((info.info.buildDate ?? "--"), buildDateColumnWidth);
								EditorGUILayout.LabelField((info.info.appendix ?? "--"), appendixColumnWidth);
							} else {
								EditorGUILayout.LabelField("--", targetColumnWidth);
								EditorGUILayout.LabelField("--", versionColumnWidth);
								EditorGUILayout.LabelField("--", buildDateColumnWidth);
								EditorGUILayout.LabelField("--", appendixColumnWidth);
							}

							EditorGUILayout.LabelField(info.path, pathColumnWidth);
						}
						EditorGUILayout.EndHorizontal();
					}
				}
				EditorGUILayout.EndVertical();
			}
			EditorGUI.indentLevel--;
			/* �ڍ׃o�[�W�������\�� */
			{
				if (GUILayout.Button("Copy Detail To Clipboard", GUILayout.Width(180))) {
					EditorGUIUtility.systemCopyBuffer = detailVersionsString;
					GUI.FocusControl("");
				}
				scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
				EditorGUILayout.BeginVertical();
				foreach (var item in detailVersionsStrings) {
					EditorGUILayout.TextArea(item);
				}
				EditorGUILayout.EndVertical();
				EditorGUILayout.EndScrollView();
			}
		}
		EditorGUILayout.EndVertical();
	}
	
	
	private void Reload()
	{
		pluginInfos = LoadPluginInfos(pluginsDirectory, pluginBinaryFilenames);
		if (pluginInfos.Count > 0) {
			/* �\���̐����̂��ߕ\���\�ȕ������Ő؂�o�� */
			detailVersionsString  = ModuleInfosToAlignedString(pluginInfos[0].moduleVersionInfos);
			detailVersionsStrings = SplitTextAreaMaxLength(detailVersionsString);
		} else {
			detailVersionsString  = "";
			detailVersionsStrings = new string[]{""};
		}
		scrollPosition = new Vector2(0.0f, 0.0f);
	}
	
	
	private string PluginVersionsString()
	{
		string[] moduleInfoStrings 
			= ModuleInfosToAlignedString(
				(from item in pluginInfos select item.info).ToList()
				).Split(new string[]{System.Environment.NewLine}, System.StringSplitOptions.None);
		int    platformLength = pluginInfos.Max(item => (item != null) ? item.platform.Length : 0);
		string platformFormat = string.Format("{{0,-{0}}}  ", platformLength);
		
		string s = "";
		s +=  "CRIWARE Unity Plugin Script Version" + System.Environment.NewLine
			+ "  Ver." + CriWare.GetScriptVersionString() + System.Environment.NewLine + System.Environment.NewLine
				+ "CRIWARE Unity Plugin Binary Version" + System.Environment.NewLine;
		for (int i = 0; i < pluginInfos.Count; i++) {
			s += "  " + string.Format(platformFormat, pluginInfos[i].platform) + moduleInfoStrings[i] + System.Environment.NewLine;
		}
		
		return s;
	}
	
	
	private static string ModuleInfosToAlignedString(List<ModuleInfo> infos)
	{
		int nameLength      = 0;
		int targetLength    = 0;
		int versionLength   = 0;
		int buildDateLength = 0;
		int appendixLength  = 0;
		foreach (var info in infos) {
			if (info != null) {
				nameLength      = System.Math.Max(nameLength,      ((info.name      != null) ? info.name.Length      : 0));
				targetLength    = System.Math.Max(targetLength  ,  ((info.target    != null) ? info.target.Length    : 0));
				versionLength   = System.Math.Max(versionLength,   ((info.version   != null) ? info.version.Length   : 0));
				buildDateLength = System.Math.Max(buildDateLength, ((info.buildDate != null) ? info.buildDate.Length : 0));
				appendixLength  = System.Math.Max(appendixLength,  ((info.appendix  != null) ? info.appendix.Length  : 0));
			}
		}
		string format = string.Format(
			"{{0,-{0}}}  {{1,-{1}}}  {{2,-{2}}}  {{3,-{3}}}  {{4,-{4}}}" + System.Environment.NewLine,
			nameLength, targetLength, versionLength, buildDateLength, appendixLength
			);
		string s = "";
		foreach (var info in infos) {
			if (info != null) {
				s += string.Format(format, info.name, info.target, info.version, info.buildDate, info.appendix);
			} else {
				s += string.Format(format, "--", "--", "--", "--", "--");
			}
		}
		return s;
	}
	
	
	private static string[] SplitTextAreaMaxLength(string s)
	{
		const int textAreaMaxLength = 16000;
		int numOfStrings = (s.Length / textAreaMaxLength) + 1;
		string[] strings = new string[numOfStrings];
		for (int i = 0; i < numOfStrings; i++) {
			int beginPos = i * textAreaMaxLength;
			int endPos   = System.Math.Min((beginPos + textAreaMaxLength), s.Length);
			strings[i]   = s.Substring(beginPos, (endPos - beginPos));
		}
		return strings;
	}
	
	
	private static List<PluginInfo> LoadPluginInfos(string pluginsDirectory, string[][] pluginBinaryFilenames)
	{
		var pluginInfos = new List<PluginInfo>();
		foreach (var item in pluginBinaryFilenames) {
			var path = System.IO.Path.Combine(pluginsDirectory, item[3]);
			var moduleVersionInfos = LoadModuleInfos(path);
			if (moduleVersionInfos != null) {
				var info                = new PluginInfo();
				info.moduleVersionInfos = moduleVersionInfos;
				info.info               = info.moduleVersionInfos.Find((minfo) => minfo.target.Contains(item[1]) && (minfo.name == item[2]));
				info.platform           = item[0];
				info.target             = info.info.target;
				info.path               = System.IO.Path.Combine("Plugins", item[3]);
				pluginInfos.Add(info);
			}
		}
		return pluginInfos;
	}
	

	private static List<ModuleInfo> LoadModuleInfos(string path)
	{
		if (!System.IO.File.Exists(path)) {
			return null;
		}
		
		var bytes = System.IO.File.ReadAllBytes(path);
		if (System.IO.Path.GetExtension(path) == ".bc") {
			return LoadModuleInfosWithBitShift(bytes);
		} else {
			return LoadModuleInfos(bytes);
		}
	}
	
	
	private static List<ModuleInfo> LoadModuleInfos(byte[] bytes)
	{
		var data  = System.Text.Encoding.ASCII.GetString(bytes);
		var infos = new List<ModuleInfo>();
		
		var versionRegex			= new System.Text.RegularExpressions.Regex("^([^/]+)(?:/(.+))? (Ver\\..+) (Build:(?:.*))$");
		var versionAppendixRegex	= new System.Text.RegularExpressions.Regex("^Append: (.*)$");
		
		int pos = 0;
		while (true) {
			pos = data.IndexOf(" Build:", pos);
			if (pos == -1) {
				break;
			}
			++pos;
			{
				int beginPos = FindNonPrintableCharBackward(data, pos);
				int endPos   = FindNonPrintableCharFoward(data, pos);
				if ((data[beginPos] != '\n') || (data[endPos] != '\n')) {
					continue;
				}
				++beginPos;
				var s = data.Substring(beginPos, (endPos - beginPos));
				var match = versionRegex.Match(s);
				if (!match.Success) {
					continue;
				}
				var info = new ModuleInfo();
				info.name       = match.Groups[1].Value;
				info.target     = match.Groups[2].Value;
				info.version    = match.Groups[3].Value;
				info.buildDate  = match.Groups[4].Value;
				/* Appendix */
				if ((endPos + 2) < data.Length) {
					int appendisBeginPos = endPos + 1;
					int appendixEndPos   = FindNonPrintableCharFoward(data, appendisBeginPos + 1);
					if ((data[appendisBeginPos] != '\0') || (data[appendixEndPos] != '\n')) {
					} else {
						++appendisBeginPos;
						s = data.Substring(appendisBeginPos, (appendixEndPos - appendisBeginPos));
						match = versionAppendixRegex.Match(s);
						if (match.Success) {
							info.appendix = match.Groups[1].Value;
						}
					}
				}
				infos.Add(info);
			}
		}
		
		/* ���W���[���������W���[�������Ƀ\�[�g */
		infos.Sort((x, y) => x.name.CompareTo(y.name) );
		
		return infos;
	}
	
	
	private static List<ModuleInfo> LoadModuleInfosWithBitShift(byte[] bytes)
	{
		var infos = LoadModuleInfos(bytes);

		for (int shift = 1; shift <= 7; shift++) {
			int rshift = 8 - shift;
			byte[] shifted = new byte[bytes.Length + 1];
			for (int i = 0; i < bytes.Length; i++) {
				shifted[i] |= (byte)((bytes[i] << shift));
				shifted[i + 1] |= (byte)(bytes[i] >> rshift);
			}
			infos.AddRange(LoadModuleInfos(shifted));
		}
		
		/* ���W���[���������W���[�������Ƀ\�[�g */
		infos.Sort((x, y) => x.name.CompareTo(y.name) );

		return infos;
	}
	
	
	private static int FindNonPrintableCharBackward(string s, int index)
	{
		for (; index >= 0; --index) {
			if ((s[index] < 32) || (s[index] > 126)) {
				break;
			}
		}
		return index;
	}
	
	
	private static int FindNonPrintableCharFoward(string s, int index)
	{
		for (; index < s.Length; index++) {
			if ((s[index] < 32) || (s[index] > 126)) {
				break;
			}
		}
		return index;
	}
}
