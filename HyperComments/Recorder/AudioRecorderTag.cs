﻿using System.Windows;
using Microsoft.VisualStudio.Text.Editor;

namespace HyperComments.Recorder
{
    public class AudioRecorderTag : IntraTextAdornmentTag
    {
        public AudioRecorderTag() : base(new UIElement(), null)
        {
            
        }
    }
}