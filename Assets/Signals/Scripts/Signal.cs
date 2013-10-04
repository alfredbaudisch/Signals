﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Signal
{
	public GameObject target;
	public string method;
	public string argType;

	public Signal()
	{

	}
	public Signal(System.Type argType)
	{
		this.argType = argType.FullName;
	}

	public void Send()
	{
		if (target != null && !string.IsNullOrEmpty(method))
			target.SendMessage(method);
	}
	public void Send(object value)
	{
		if (argType != null)
		{
			if (target != null && !string.IsNullOrEmpty(method))
			{
				if (argType.Equals(value.GetType().FullName))
					target.SendMessage(method, value);
				else
					Debug.LogError("Incorrect parameter type, expected [" + argType + "], got [" + value.GetType().FullName + "].");
			}
		}
		else
			Send();
	}
}

public class SignalAttribute : System.Attribute
{

}