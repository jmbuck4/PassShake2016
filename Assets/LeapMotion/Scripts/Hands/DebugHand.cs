﻿/******************************************************************************\
<<<<<<< HEAD
* Copyright (C) Leap Motion, Inc. 2011-2016.                                   *
=======
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
>>>>>>> refs/remotes/origin/master
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

<<<<<<< HEAD
namespace Leap.Unity {
  /**
   * A HandModel that draws lines for the bones in the hand and its fingers.
   *
   * The debugs lines are only drawn in the Editor Scene view (when a hand is tracked) and
   * not in the Game view. Use debug hands when you aren't using visible hands in a scene
   * so that you can see where the hands are in the scene view.
   * */
  public class DebugHand : IHandModel {
    private Hand hand_;

    [SerializeField]
    private bool visualizeBasis = true;
    public bool VisualizeBasis { get { return visualizeBasis; } set { visualizeBasis = value; } }

    /** The colors used for each bone. */
    protected Color[] colors = { Color.gray, Color.yellow, Color.cyan, Color.magenta };

    public override ModelType HandModelType {
      get {
        return ModelType.Graphics;
      }
    }

    [SerializeField]
    private Chirality handedness;
    public override Chirality Handedness {
      get {
        return handedness;
      }
      set { }
    }

    public override Hand GetLeapHand() {
      return hand_;
    }

    public override void SetLeapHand(Hand hand) {
      hand_ = hand;
    }

    public override bool SupportsEditorPersistence() {
      return true;
    }

    /**
    * Initializes the hand and calls the line drawing function.
    */
    public override void InitHand() {
      DrawDebugLines();
    }

    /**
    * Updates the hand and calls the line drawing function.
    */
    public override void UpdateHand() {
      DrawDebugLines();
    }

    /**
    * Draws lines from elbow to wrist, wrist to palm, and normal to the palm.
    */
    protected void DrawDebugLines() {
      Hand hand = GetLeapHand();
      Debug.DrawLine(hand.Arm.ElbowPosition.ToVector3(), hand.Arm.WristPosition.ToVector3(), Color.red); //Arm
      Debug.DrawLine(hand.WristPosition.ToVector3(), hand.PalmPosition.ToVector3(), Color.white); //Wrist to palm line
      Debug.DrawLine(hand.PalmPosition.ToVector3(), (hand.PalmPosition + hand.PalmNormal * hand.PalmWidth / 2).ToVector3(), Color.black); //Hand Normal

      if (VisualizeBasis) {
        DrawBasis(hand.PalmPosition, hand.Basis, hand.PalmWidth / 4); //Hand basis
        DrawBasis(hand.Arm.ElbowPosition, hand.Arm.Basis, .01f); //Arm basis
      }

      for (int f = 0; f < 5; f++) { //Fingers
        Finger finger = hand.Fingers[f];
        for (int i = 0; i < 4; ++i) {
          Bone bone = finger.Bone((Bone.BoneType)i);
          Debug.DrawLine(bone.PrevJoint.ToVector3(), bone.PrevJoint.ToVector3() + bone.Direction.ToVector3() * bone.Length, colors[i]);
          if (VisualizeBasis)
            DrawBasis(bone.PrevJoint, bone.Basis, .01f);
        }
      }
    }

    public void DrawBasis(Vector position, LeapTransform basis, float scale) {
      Vector3 origin = position.ToVector3();
      Debug.DrawLine(origin, origin + basis.xBasis.ToVector3() * scale, Color.red);
      Debug.DrawLine(origin, origin + basis.yBasis.ToVector3() * scale, Color.green);
      Debug.DrawLine(origin, origin + basis.zBasis.ToVector3() * scale, Color.blue);
    }

=======
/**
 * A HandModel that draws lines for the bones in the hand and its fingers.
 * 
 * The debugs lines are only drawn in the Editor Scene view (when a hand is tracked) and
 * not in the Game view. Use debug hands when you aren't using visible hands in a scene
 * so that you can see where the hands are in the scene view.
 * */
public class DebugHand : HandModel {

  /**
  * Initializes the hand and calls the line drawing function.
  */
  public override void InitHand() {
    for (int f = 0; f < fingers.Length; ++f) {
      if (fingers[f] != null)
        fingers[f].InitFinger();
    }

    DrawDebugLines();
  }

  /**
  * Updates the hand and calls the line drawing function.
  */
  public override void UpdateHand() {
    for (int f = 0; f < fingers.Length; ++f) {
      if (fingers[f] != null)
        fingers[f].UpdateFinger();
    }

    DrawDebugLines();
  }

  /**
  * Draws lines from elbow to wrist, wrist to palm, and normal to the palm.
  */
  protected void DrawDebugLines() {
    HandModel hand = GetComponent<HandModel>();
    Debug.DrawLine(hand.GetElbowPosition(), hand.GetWristPosition(), Color.red);
    Debug.DrawLine(hand.GetWristPosition(), hand.GetPalmPosition(), Color.white);
    Debug.DrawLine(hand.GetPalmPosition(),
                   hand.GetPalmPosition() + hand.GetPalmNormal(), Color.black);
    Debug.Log(Vector3.Dot(hand.GetPalmDirection(), hand.GetPalmNormal()));
>>>>>>> refs/remotes/origin/master
  }
}
