using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool.Analytics.UnityAnalytics
{
    public class Dev2DevAnalyticsService : IAnalyticsService
    {
        public void SendEvent(string eventName)
        {
            throw new System.NotImplementedException();
        }

        public void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
