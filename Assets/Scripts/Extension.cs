using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public static class Extension
    {
        private static Dictionary<DirectionType, Vector3> _rotation;
        private static Dictionary<DirectionType, Vector3> _position;

       static Extension()
        {
        _position = new Dictionary<DirectionType, Vector3>()
        {
            {DirectionType.Up, new Vector3(0,1,0) },
            {DirectionType.Down, new Vector3(0,-1,0) },
            {DirectionType.Left, new Vector3(-1,0,0) },
            {DirectionType.Right, new Vector3(1,0,0) },
        };
        _rotation = new Dictionary<DirectionType, Vector3>()
         {
            {DirectionType.Up, new Vector3(0,0,0) },
            {DirectionType.Down, new Vector3(0,0,180) },
            {DirectionType.Left, new Vector3(0,0,90) },
            {DirectionType.Right, new Vector3(0,0,270) },
        };
        }

        public static Vector3 ConvertDirectionToPosition(this DirectionType direction) =>
            _position[direction];
        public static DirectionType ConvertPositionToDirection(this Vector3 position) =>
           _position.FirstOrDefault(t => t.Value == position).Key;
        public static DirectionType ConvertPositionToDirection(this Vector2 position) => 
            ConvertPositionToDirection((Vector3)position);
        

        public static DirectionType ConvertRotationToDirection(this Vector3 rotation) =>
            _rotation.First(t => t.Value == rotation).Key;
        public static Vector3 ConvertDirectionToRotation(this DirectionType direction) =>
           _rotation[direction];

    

    }
public enum SideType : byte
{
    None, Player, Enemy
}
public enum DirectionType : byte
{
  Up, Down, Left, Right
}
