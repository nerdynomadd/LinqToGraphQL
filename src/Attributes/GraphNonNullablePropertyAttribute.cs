﻿using System;

namespace Client.Attributes
{
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
	public class GraphNonNullablePropertyAttribute : Attribute
	{
		
	}
}