using Godot;
using System;

public partial class BackgroundMusic : AudioStreamPlayer
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
   /// Detect when the sound has finished playing and play it again to make it loop.
   /// As of this present version of Godot, it does not appear to be looping as intended
   /// even with multiple re-imports of the WAV file.
   /// </summary>
   public void OnFinished()
   {
      Play();
   }
}
