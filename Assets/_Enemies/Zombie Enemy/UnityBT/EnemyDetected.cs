using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Enemy Detected")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Enemy Detected", message: "Detects enemy and get alert", category: "Events", id: "1c5a197d0d0edbff9bd70cae85e7f8f6")]
public sealed partial class EnemyDetected : EventChannel { }

