using Godot;
using System;

public partial class Player : CharacterBody2D
{
   #region Public Editor Properties

   [Export]
   public float Gravity { get; set; } = 400.0f;

   [Export]
   public int WalkSpeed { get; set; } = 400;

   [Export]
   public float JumpVelocity { get; set; } = -400.0f;

   [Export]
   public float Height { get; set; } = 121; // Snagging the animation frame's sprite height is convoluded. Do this instead.

   [Export]
   public float Width { get; set; } = 96; // Snagging the animation frame's sprite width is convoluded. Do this instead.

   #endregion

   #region Public Methods

   /// <summary>
   /// Called when the node enters the scene tree for the first time.
   /// </summary>
   public override void _Ready()
   {
      // Cache values that need to be referenced to avoid function calls in tight game frame loops.
      _screenSize = GetViewportRect().Size;
      _startingPosition = Position;

      // Set the default animation to "idle" and start it.
      _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
      _animatedSprite2D.Animation = "idle";
      _animatedSprite2D.Play();
   }

   /// <summary>
   /// Handles the physics game frame. Required for kinetic objects.
   /// </summary>
   /// <param name="delta"></param>
   public override void _PhysicsProcess(double delta)
   {
      // Cache the current velocity for local manipulation.
      var velocity = Velocity;

      // If the player is mid-air, do a general fall.
      if (!IsOnFloor())
      {
         velocity.Y += Gravity * (float)delta;
      }

      // If the player is grounded and does the jump action, calculate
      // the velocity differently.
      if (Input.IsActionPressed("jump") && IsOnFloor())
      {
         velocity.Y = JumpVelocity;
      }

      // Handle input of left or right to determine X velocity and direction.
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

      // Set the final velocity value.
      Velocity = velocity;
      if (Velocity.Length() > 0)
      {
         // If the player is moving in either direction, activate the 
         // walking animation.
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
         // Default to the idle animation when the player isn't doing
         // something specific.
         _animatedSprite2D.Animation = "idle";
      }

      // "MoveAndSlide" already takes delta time into account.
      MoveAndSlide();
   }

   /// <summary>
   /// Forces the player to die and reset to the starting position.
   /// </summary>
   public void DieAndReset()
   {
      Position = _startingPosition;
   }

   #endregion

   #region Private Members

   private AnimatedSprite2D _animatedSprite2D;

   private Vector2 _screenSize;

   private Vector2 _startingPosition;

   #endregion
}
