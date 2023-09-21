using Godot;
using System;

public partial class BlueFlag : Area2D
{
   #region Public Methods

   /// <summary>
   /// Called when the node enters the scene tree for the first time.
   /// </summary>
   public override void _Ready()
   {
      // Cache the collision shape to avoid the map lookup on each physics pass.
      _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
      if (_collisionShape2D != null)
      {
         _collisionShape2D.Disabled = false;
      }
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
         var label = GetNode<RichTextLabel>("HelloWorldLabel");
         if (label != null)
         {
            label.Show();
         }
      }
   }

   /// <summary>
   /// Handles when a foreign body exits this object's collision zone.
   /// </summary>
   /// <param name="body">The body that exited.</param>
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

   #endregion

   #region Private Members

   private CollisionShape2D _collisionShape2D;

   #endregion
}
