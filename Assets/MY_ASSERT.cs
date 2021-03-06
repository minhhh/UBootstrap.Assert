﻿using UnityEngine;
using System.Collections;

namespace UBootstrap
{
    public partial class CUSTOM_ASSERT
    {
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void IsNotNull (object value, string message = "", params object[] args)
        {
            IsNotNull (value, 1, message, args);
        }

        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        // Adding , params object[] args will cause Error 
        static public void Fail (string message = "")
        {
            Fail (2, message);
        }
    }
}