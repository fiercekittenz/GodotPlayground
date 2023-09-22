using Godot;
using System;

public partial class PickupItem : Area2D
{
   // Called when the node enters the scene tree for the first time.
   public override void _Ready()
   {
   }

   // Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(double delta)
   {
   }

   /// <summary>
   /// Handles when a foreign body enters this object's collision zone.
   /// </summary>
   /// <param name="body">The body that entered.</param>
   private void OnBodyEntered(Node2D body)
   {
      if (body is Player player)
      {
         player.Collect();
         if (!IsQueuedForDeletion())
         {
            QueueFree();
         }
      }
   }
}
