using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[Serializable] public class DoorEvent : UnityEvent<Door> { }
[Serializable] public class TransformEvent : UnityEvent<Transform> { }