using Godot;
using System;

public partial class Player : CharacterBody2D
{
   #region Public Properties

   [Export]
   public float Gravity { get; set; } = 400.0f;
   public int WalkSpeed { get; set; } = 400;

   public Vector2 ScreenSize; // Size of the game window.

   public float Height { get; set; } = 121; // Snagging the animation frame's sprite height is convoluded. Do this instead.
   public float Width { get; set; } = 96; // Snagging the animation frame's sprite width is convoluded. Do this instead.

   #endregion

   #region Public Methods

   // Called when the node enters the scene tree for the first time.
   public override void _Ready()
   {
      ScreenSize = GetViewportRect().Size;

      GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;

      _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
      _animatedSprite2D.Animation = "idle";
      _animatedSprite2D.Play();
   }

   public override void _PhysicsProcess(double delta)
   {
      var velocity = Velocity;

      velocity.Y += (float)delta * Gravity;

      if (Input.IsActionPressed("move_left"))
      {
         velocity.X = -WalkSpeed;
      }
      else if (Input.IsActionPressed("move_right"))
      {
         velocity.X = WalkSpeed;
      }
      else
      {
         velocity.X = 0;
      }

      Velocity = velocity;
      if (Velocity.Length() > 0)
      {
         _animatedSprite2D.Animation = "walking";

         // Flip the animation based on direction.
         if (velocity.X < 0)
         {
            _animatedSprite2D.FlipH = true;
         }
         else
         {
            _animatedSprite2D.FlipH = false;
         }
      }
      else
      {
         _animatedSprite2D.Animation = "idle";
      }

      // "MoveAndSlide" already takes delta time into account.
      MoveAndSlide();
   }

   #endregion

   #region Private Members

   private AnimatedSprite2D _animatedSprite2D;

   #endregion
}
