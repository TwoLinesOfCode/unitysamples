//using UnityEngine;
//using UnityEngine.Events;
//using System.Collections;
//using System.Collections.Generic;
//using Assets.Scripts.Enum;
//using System;

//public class EventManager
//{
//	private Dictionary<string, UnityEvent<object>> eventDictionary;

//	private static EventManager eventManager;

//	public static EventManager instance
//	{
//		get
//		{
//			if (eventManager == null)
//			{
//				eventManager = new EventManager();
//			}

//			return eventManager;
//		}
//	}

//	private EventManager()
//	{

//		eventDictionary = new Dictionary<string, UnityEvent<object>>();
//	}

//	public static void StartListening(string eventName, UnityEvent<object> listener)
//	{
//		UnityEvent<object> thisEvent = null;
//		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
//		{
//			thisEvent.AddListener(listener);
//		}
//		else
//		{
//			thisEvent = new UnityEvent<object>;
//			thisEvent.AddListener(listener);
//			instance.eventDictionary.Add(eventName, thisEvent);
//		}
//	}

//	public static void StopListening(string eventName, UnityAction listener)
//	{
//		if (eventManager == null) return;
//		UnityEvent thisEvent = null;
//		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
//		{
//			thisEvent.RemoveListener(listener);
//		}
//	}

//	public static void TriggerEvent(string eventName)
//	{
//		UnityEvent thisEvent = null;
//		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
//		{
//			thisEvent.Invoke();
//		}
//	}
//}