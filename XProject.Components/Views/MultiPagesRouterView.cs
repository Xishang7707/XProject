using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XProject.Components.Views
{
    /// <summary>
    /// 多页面路由
    /// </summary>
    public class MultiPagesRouterView : RouteView
    {
        protected override void Render(RenderTreeBuilder builder)
        {
            var layoutType = RouteData.PageType.GetCustomAttribute<LayoutAttribute>()?.LayoutType ?? DefaultLayout;

            builder.OpenComponent(0, layoutType);

            builder.AddAttribute(1, "Body", CreateBody(RouteData.PageType, RouteData.RouteValues));

            if (typeof(MultiPagesRouterLayout).IsAssignableFrom(layoutType))
            {
                builder.AddAttribute(2, "PageType", RouteData.PageType);
                builder.AddAttribute(3, "RouteValues", RouteData.RouteValues);
            }

            builder.CloseComponent();

        }
        static RenderFragment CreateBody(Type PageType, IReadOnlyDictionary<string, object> RouteValues)
        {
            return RenderForType;
            void RenderForType(RenderTreeBuilder builder)
            {
                builder.OpenComponent(0, PageType);
                foreach (KeyValuePair<string, object> routeValue in RouteValues)
                {
                    builder.AddAttribute(1, routeValue.Key, routeValue.Value);
                }
                builder.CloseComponent();
            }
        }
    }

    public class MultiPagesRouterLayout : LayoutComponentBase
    {
        [Parameter]
        public Type PageType { get; set; }

        [Parameter]
        public IReadOnlyDictionary<string, object> RouteValues { get; set; }
    }

    public interface IMultiPagesTabPage
    {
        string GetTabButtonText();
    }
}
