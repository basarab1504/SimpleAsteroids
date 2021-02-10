using System;

namespace SimpleAsteroids
{
    public class Time
    {
        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;

        private float deltaTime;

        public float DeltaTime => deltaTime;

        public void Update()
        {
            time2 = DateTime.Now;
            deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            time1 = time2;
        }
    }
}
