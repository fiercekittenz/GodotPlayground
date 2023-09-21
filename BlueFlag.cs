using Godot;
using System;

public partial class BlueFlag : Area2D
{
   // Called when the node enters the scene tree for the first time.
   public override void _Ready()
   {
      mCollisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
      if (mCollisionShape2D != null)
      {
         mCollisionShape2D.Disabled = false;
      }
   }

   // Called every frame. 'delta' is the elapsed time since the previous frame.
   public override void _Process(double delta)
   {
   }

   private void OnBodyEntered(Node2D body)
   {
      if (body != null && body.IsInGroup("Player"))
      {
         var label = GetNode<RichTextLabel>("HelloWorldLabel");
         if (label != null)
         {
            label.Show();
         }
      }
   }

   private void OnBodyExit(Node2D body)
   {
      if (body != null && body.IsInGroup("Player"))
      {
         var label = GetNode<RichTextLabel>("HelloWorldLabel");
         if (label != null)
         {
            label.Hide();
         }
      }
   }

   private CollisionShape2D mCollisionShape2D;
}
