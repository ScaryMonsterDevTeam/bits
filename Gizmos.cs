/* This file adds a editor menu in Windows->Gizmos to enable/disable all the gizmo checkmarks*/
using UnityEditor;
 using System;
 using System.Reflection;
 
 public class DisableAllGizmos
 {
     [MenuItem("Window/Gizmos/Disable All Gizmos")]
     static void DisableAllGizmosMenu()
     {
         var Annotation = Type.GetType("UnityEditor.Annotation, UnityEditor");
         var ClassId = Annotation.GetField("classID");
         var ScriptClass = Annotation.GetField("scriptClass");
         
         Type AnnotationUtility = Type.GetType("UnityEditor.AnnotationUtility, UnityEditor");
         var GetAnnotations = AnnotationUtility.GetMethod("GetAnnotations", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
         var SetGizmoEnabled = AnnotationUtility.GetMethod("SetGizmoEnabled", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
         var SetIconEnabled = AnnotationUtility.GetMethod("SetIconEnabled", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
 
         Array annotations = (Array)GetAnnotations.Invoke(null, null);
         foreach (var a in annotations)
         {
             int classId = (int)ClassId.GetValue(a);
             string scriptClass = (string)ScriptClass.GetValue(a);
 
             SetGizmoEnabled.Invoke(null, new object[] { classId, scriptClass, 0, false });
             SetIconEnabled.Invoke(null, new object[] { classId, scriptClass, 0 });
         }
     }
     [MenuItem("Window/Gizmos/Enable All Gizmos")]
     static void EnableAllGizmosMenu()
     {
         var Annotation = Type.GetType("UnityEditor.Annotation, UnityEditor");
         var ClassId = Annotation.GetField("classID");
         var ScriptClass = Annotation.GetField("scriptClass");
         
         Type AnnotationUtility = Type.GetType("UnityEditor.AnnotationUtility, UnityEditor");
         var GetAnnotations = AnnotationUtility.GetMethod("GetAnnotations", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
         var SetGizmoEnabled = AnnotationUtility.GetMethod("SetGizmoEnabled", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
         var SetIconEnabled = AnnotationUtility.GetMethod("SetIconEnabled", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
 
         Array annotations = (Array)GetAnnotations.Invoke(null, null);
         foreach (var a in annotations)
         {
             int classId = (int)ClassId.GetValue(a);
             string scriptClass = (string)ScriptClass.GetValue(a);
 
             SetGizmoEnabled.Invoke(null, new object[] { classId, scriptClass, 1, false });
             SetIconEnabled.Invoke(null, new object[] { classId, scriptClass, 1 });
         }
     }
 }
