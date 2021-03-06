﻿namespace LINQPadUtils.Markup
{
    using System;

    public class HtmlTag : IEquatable<HtmlTag>
    {
        HtmlTag()
        {
        }

        public string TagName { private get; set; }

        public string TagDisplayText { private get; set; }

        public bool Equals(HtmlTag other)
        {
            return this.TagName == other.TagName && this.TagDisplayText == other.TagDisplayText;
        }

        public override string ToString()
        {
            return String.Format("<{0}>{1}</{0}>", this.TagName, this.TagDisplayText);
        }

        public static HtmlTag WrapValue(string tag, string value)
        {
            return new HtmlTag
                   {
                       TagDisplayText = value,
                       TagName = tag
                   };
        }
    }
}