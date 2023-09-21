using Godot;
using System;

public partial class DeathZone : Area2D
{
   /// <summary>
   /// Called when the node enters the scene tree for the first time.
   /// </summary>
   public override void _Ready()
   {
   }

   /// <summary>
   /// Called every frame. 'delta' is the elapsed time since the previous frame.
   /// </summary>
   /// <param name="delta"></param>
   public override void _Process(double delta)
   {
   }

   /// <summary>
   /// Handles when a foreign body enters this object's collision zone.
   /// </summary>
   /// <param name="body">The body that entered.</param>
   private void OnBodyEntered(Node2D body)
   {
      if (body != null && body.IsInGroup("Player"))
      {
         Player player = body as Player;
         player.DieAndReset();
      }
   }
}
