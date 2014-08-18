namespace LINQPadUtils.Fragments
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    using LINQPadUtils.Markup;
    using LINQPadUtils.MetadataProviders;

    class EnumerableComplexObjectTableRowsFragment : FragmentBase
    {
        public EnumerableComplexObjectTableRowsFragment(TypeMetadataProviderBase metadata)
            : base(metadata) { }

        public override string Render()
        {
            var rowDataSb = new StringBuilder();

            if (this.Metadata.IsEnumerable)
            {
                // check the collection to see if it's all strongly typed, or all primitives so the columns can be built.
                foreach (var item in (IEnumerable)this.Metadata.SourceObject)
                {
                    rowDataSb.Append("<tr>");

                    foreach (var propertyInfo in base.Metadata.Properties)
                    {
                        object value = propertyInfo.GetValue(item);

                        string renderedValue = ValueInspector.GetDisplayValue(value, propertyInfo.PropertyType);

                        var newTag = HtmlTag.WrapValue("td", renderedValue);

                        rowDataSb.Append(newTag);
                    } 

                    rowDataSb.Append("</tr>");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot render rows for a type which does not implement IEnumerable.");
            }
            
            return rowDataSb.ToString();
        }
    }
}