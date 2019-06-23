﻿/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(CriWareInitializer))]
public class CriWareInitializerEditor : Editor 
{	
	private void GenToggleField(string label_str, string tooltip, ref bool field_value)
	{
		GUIContent content = new GUIContent(label_str, tooltip);
		field_value = EditorGUILayout.Toggle(content, field_value);
	}
	
	private void GenIntField(string label_str, string tooltip, ref int field_value, int min, int max)
	{
		GUIContent content = new GUIContent(label_str, tooltip);
		field_value = Math.Min(max, Math.Max(min, EditorGUILayout.IntField(content, field_value)));
	}

    private void GenIntFieldWithUnit(string label_str, string label_unit, string tooltip, ref int field_value, int min, int max)
    {
        //GUIContent content = new GUIContent(label_str, tooltip);
        //field_value = Math.Min(max, Math.Max(min, EditorGUILayout.IntField(content, field_value)));

        EditorGUILayout.BeginHorizontal();
        {
            GUIContent content = new GUIContent(label_str, tooltip);
            field_value = Math.Min(max, Math.Max(min, EditorGUILayout.IntField(content, field_value)));
            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            EditorGUILayout.LabelField(label_unit);
            EditorGUI.indentLevel = indentLevel;
        }
        EditorGUILayout.EndHorizontal();

    }

    private void GenPositiveFloatField(string label_str, string tooltip, ref float field_value, float min, float max)
	{
		GUIContent content = new GUIContent(label_str, tooltip);
		field_value = Math.Min(max, Math.Max(min, EditorGUILayout.FloatField(content, field_value)));
	}

	private void GenPositiveFloatField(string label_str, string label_unit, string tooltip, ref float field_value, float min, float max)
	{
		EditorGUILayout.BeginHorizontal();
		{
			GUIContent content = new GUIContent(label_str, tooltip);
			field_value = Math.Min(max, Math.Max(min, EditorGUILayout.FloatField(content, field_value)));
			int indentLevel = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			EditorGUILayout.LabelField(label_unit);
			EditorGUI.indentLevel = indentLevel;
		}
		EditorGUILayout.EndHorizontal();
	}

	private void GenStringField(string label_str, string tooltip, ref string field_value)
	{
		GUIContent content = new GUIContent(label_str, tooltip);
		field_value = EditorGUILayout.TextField(content, field_value);
	}

	private Enum GenEnumField(string label_str, string tooltip, Enum field_value)
	{
		EditorGUILayout.BeginHorizontal();
		{
			GUIContent content = new GUIContent(label_str, tooltip);
			field_value = EditorGUILayout.EnumPopup(content, field_value);
		}
		EditorGUILayout.EndHorizontal();
		return field_value;
	}

	static private bool showFileSystemAndroidConfig     = false;
	static private bool showAtomStandardVoicePoolConfig = false;
	static private bool showAtomHcaMxVoicePoolConfig    = false;
	static private bool showAtomPCConfig = false;
	static private bool showAtomIOSConfig = false;
	static private bool showAtomAndroidConfig           = false;
	static private bool showAtomAndroidVoicePoolConfig  = true;
	
	static private string[] asrOutputModes = {"Default", "Stereo", "4ch", "6ch(5.1ch)", "8ch(7.1ch)"};
	static private int[] asrNumOutputChannels = {0, 2, 4, 6, 8};

	public override void OnInspectorGUI()
	{
		CriWareInitializer initializer = target as CriWareInitializer;

		Undo.RecordObject(target, null);

		GUI.changed = false;
		{
			// FileSystem Config
			initializer.initializesFileSystem = 
				EditorGUILayout.BeginToggleGroup("Initialize FileSystem", initializer.initializesFileSystem);
			EditorGUI.indentLevel += 1;
			{	
				GenIntField("Number of Loaders",        "The maximum number of CriFsLoader objects used at a time. " +
					"NOTE: Count the number of CriFsLoadFileRequest objects and the total number of Streaming Voices in CRI Atom settings and the number of CriMana.Player component,", 
					ref initializer.fileSystemConfig.numberOfLoaders,    0,  128);
				GenIntField("Number of Binders",        "", ref initializer.fileSystemConfig.numberOfBinders,    0,  128);
				GenIntField("Number of Installers",     "", ref initializer.fileSystemConfig.numberOfInstallers, 0,  128);
				GenIntFieldWithUnit("Install Buffer Size", "[KiB]", "Internal buffer size to install data. A larger buffer size result in better performance.", ref initializer.fileSystemConfig.installBufferSize,  32, int.MaxValue);
				GenIntField("Max Length of Path",       "The maximum length of path (file path or url path) that can be passed.", ref initializer.fileSystemConfig.maxPath, 64,  2048);
				GenStringField("User Agent String",     "", ref initializer.fileSystemConfig.userAgentString);
				GenToggleField("Minimize FD Usage",    "With this option, the plugin minimizes file descriptor usage so that applicaiton can save file descriptor resource. However, this may increase file I/O instead.", ref initializer.fileSystemConfig.minimizeFileDescriptorUsage);

				showFileSystemAndroidConfig = EditorGUILayout.Foldout(showFileSystemAndroidConfig, "Android Config");
				if (showFileSystemAndroidConfig) {
					EditorGUI.indentLevel += 1;
					{
						/* Ver.2.03.03 以前は 0 がデフォルト値だったことの互換性維持のための処理 */
						if (initializer.fileSystemConfig.androidDeviceReadBitrate == 0) {
							initializer.fileSystemConfig.androidDeviceReadBitrate = CriFsConfig.defaultAndroidDeviceReadBitrate;
						}
					}
                    GenIntFieldWithUnit("Device Read Bitrate",  "[bps]", "Expected minimum device read bitrate to be used for multi-streaming management." + CriFsConfig.defaultAndroidDeviceReadBitrate + " bps", 
						ref initializer.fileSystemConfig.androidDeviceReadBitrate, 0, int.MaxValue);
					EditorGUI.indentLevel -= 1;
				}
			}
			EditorGUI.indentLevel -= 1;
			EditorGUILayout.EndToggleGroup();
			
			// Atom Config
			initializer.initializesAtom = 
				EditorGUILayout.BeginToggleGroup("Initialize Atom", initializer.initializesAtom);
			EditorGUI.indentLevel += 1;
			{


				GenStringField("ACF File Name",           "", ref initializer.atomConfig.acfFileName);
				GenIntField("Max Virtual Voices",         "", ref initializer.atomConfig.maxVirtualVoices,      CriAtomPlugin.GetRequiredMaxVirtualVoices(initializer.atomConfig),    1024);
				GenIntField("Max Voice Limit Groups", "", ref initializer.atomConfig.maxVoiceLimitGroups, 0, 1024);
				GenIntField("Max Parameter Blocks", "", ref initializer.atomConfig.maxParameterBlocks, 1024, 4096);
				GenIntField("Max Buses", "Maximum number of buses.", ref initializer.atomConfig.maxBuses, 1, 64);
				GenIntField("Max Categories", "Maximum number of categories.", ref initializer.atomConfig.maxCategories, 0, 1024);
				GenIntField("Max Sequence Events Per Frame", "Maximum number of sequence events that will be triggered in one application frame.", ref initializer.atomConfig.maxSequenceEventsPerFrame, 0, 64);
				GenIntField("Max Beat Sync Callbacks Per Frame", "Maximum number of beat synchronized callback that will be triggered in one application frame.", ref initializer.atomConfig.maxBeatSyncCallbacksPerFrame, 0, 64);
				GenIntField("Categories per Playback", "Number of category references per playback.", ref initializer.atomConfig.categoriesPerPlayback, 0, 16);
				GenIntFieldWithUnit("Sampling Rate", "[Hz]",
					"Sound output sampling rate. "
					+ "HCA-MX needs to set the sampling rate of HCA-MX data. "
					+ "A value of 0 (the default value) means that the internal value will be applied.",
					ref initializer.atomConfig.outputSamplingRate,    0,    192000);
				GenPositiveFloatField("Server Frequency", "[Hz]", "", ref initializer.atomConfig.serverFrequency, 15.0f, 120.0f);

				int selected_output_mode = 0;
				foreach (int num_channnels in asrNumOutputChannels) {
					if (num_channnels == initializer.atomConfig.asrOutputChannels) {
						break;
					}
					selected_output_mode++;
				}
				selected_output_mode = EditorGUILayout.Popup("ASR Output Mode", selected_output_mode, asrOutputModes);
				initializer.atomConfig.asrOutputChannels = asrNumOutputChannels[selected_output_mode];

				GenToggleField("Uses Time For Seed",    "", ref initializer.atomConfig.useRandomSeedWithTime);
                GenToggleField("Uses In Game Preview", "", ref initializer.atomConfig.usesInGamePreview);
                GenToggleField("VR Mode", "", ref initializer.atomConfig.vrMode);


				showAtomStandardVoicePoolConfig = EditorGUILayout.Foldout(showAtomStandardVoicePoolConfig, "Standard Voice Pool Config");
				if (showAtomStandardVoicePoolConfig) {
					EditorGUI.indentLevel += 1;
					GenIntField("Memory Voices", "", ref initializer.atomConfig.standardVoicePoolConfig.memoryVoices,        0, 1024);
					GenIntField("Streaming Voices", "", ref initializer.atomConfig.standardVoicePoolConfig.streamingVoices, 0, 1024);
					EditorGUI.indentLevel -= 1;
				}
				
				showAtomHcaMxVoicePoolConfig = EditorGUILayout.Foldout(showAtomHcaMxVoicePoolConfig, "HCA-MX Voice Pool Config");
				if (showAtomHcaMxVoicePoolConfig) {
					EditorGUI.indentLevel += 1;
					GenIntField("Memory Voices", "", ref initializer.atomConfig.hcaMxVoicePoolConfig.memoryVoices,        0, 1024);
					GenIntField("Streaming Voices", "", ref initializer.atomConfig.hcaMxVoicePoolConfig.streamingVoices, 0, 1024);
					EditorGUI.indentLevel -= 1;
				}

				showAtomPCConfig = EditorGUILayout.Foldout(showAtomPCConfig, "PC Config");
				if (showAtomPCConfig) {
					EditorGUI.indentLevel += 1;
					GenIntFieldWithUnit("Buffering Time", "[msec]", "Sound buffering time in msec.", ref initializer.atomConfig.pcBufferingTime, 0, 2000);
					EditorGUI.indentLevel -= 1;
				}

				showAtomIOSConfig = EditorGUILayout.Foldout(showAtomIOSConfig, "iOS Config");
				if (showAtomIOSConfig) {
					EditorGUI.indentLevel += 1;
                    GenIntFieldWithUnit("Buffering Time", "[msec]", "Sound buffering time in msec.", ref initializer.atomConfig.iosBufferingTime, 16, 200);
					GenToggleField("Override iPod Music", "", ref initializer.atomConfig.iosOverrideIPodMusic);
					EditorGUI.indentLevel -= 1;
				}

				showAtomAndroidConfig = EditorGUILayout.Foldout(showAtomAndroidConfig, "Android Config");
				if (showAtomAndroidConfig) {
					EditorGUI.indentLevel += 1;
					{
						/* Ver.2.03.03 以前は 0 がデフォルト値だったことの互換性維持のための処理 */
						if (initializer.atomConfig.androidBufferingTime == 0) {
							initializer.atomConfig.androidBufferingTime = (int)(4 * 1000.0 / initializer.atomConfig.serverFrequency);
						}
						if (initializer.atomConfig.androidStartBufferingTime == 0) {
							initializer.atomConfig.androidStartBufferingTime = (int)(3 * 1000.0 / initializer.atomConfig.serverFrequency);
						}
					}
					GenIntFieldWithUnit("Buffering Time", "[msec]", "Sound buffering time in msec.", ref initializer.atomConfig.androidBufferingTime, 50, 500);
					GenIntFieldWithUnit("Start Buffering", "[msec]", "Sound buffering time to start playing. This value will be applied when using the low latency voice pool.", ref initializer.atomConfig.androidStartBufferingTime, 50, 500);
					showAtomAndroidVoicePoolConfig = EditorGUILayout.Foldout(showAtomAndroidVoicePoolConfig, "Low Latency Standard Voice Pool Config");
					if (showAtomAndroidVoicePoolConfig) {
						EditorGUI.indentLevel += 1;
						GenIntField("Memory Voices", "", ref initializer.atomConfig.androidLowLatencyStandardVoicePoolConfig.memoryVoices,        0, 32);
						GenIntField("Streaming Voices", "", ref initializer.atomConfig.androidLowLatencyStandardVoicePoolConfig.streamingVoices, 0, 32);
						EditorGUI.indentLevel -= 1;
					}
					GenToggleField("Uses Android Fast Mixer", "", ref initializer.atomConfig.androidUsesAndroidFastMixer);
					GenToggleField("Use Asr For Default Playback", "", ref initializer.atomConfig.androidForceToUseAsrForDefaultPlayback);
					EditorGUI.indentLevel -= 1;
				}
			}
			EditorGUI.indentLevel -= 1;
			EditorGUILayout.EndToggleGroup();

			GenToggleField("Dont Initialize On Awake", "", ref initializer.dontInitializeOnAwake);
			GenToggleField("Dont Destroy On Load",    "", ref initializer.dontDestroyOnLoad);
		}
		if (GUI.changed) {
			EditorUtility.SetDirty(initializer);
		}
	}
} // end of class

/* end of file */