// using System;
// using System.Collections.Generic;
// using System.Numerics;

// namespace SimpleAsteroids
// {
//     public class Arena
//     {
//         public int FromZeroSteps { get; set; }

//         public void Update(IEnumerable<Transform> transforms)
//         {
//             foreach (var item in transforms)
//                 if (IsCrossedBorders(item))
//                     item.Position = RevertedPosition(item.Position);
//         }

//         private bool IsCrossedBorders(Transform transform)
//         {
//             float x = transform.Position.X;
//             float y = transform.Position.Y;

//             return (x >= FromZeroSteps || x <= -FromZeroSteps || y >= FromZeroSteps || y <= -FromZeroSteps);
//         }

//         private Vector2 RevertedPosition(Vector2 position)
//         {
//             float x = position.X;
//             float y = position.Y;

//             if (MathF.Abs(x) >= MathF.Abs(y))
//                 return new Vector2(-x, y);
//             else
//                 return new Vector2(x, -y);
//         }
//     }
// }
