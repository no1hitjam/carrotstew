using UnityEngine;
using System.Collections.Generic;

class Behaviors
{
    public static SpriteBehavior BuildSpriteBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return SpriteBehavior.InitializeSpriteBehavior(new GameObject().AddComponent<SpriteBehavior>(), collider_type, sprite_path, x, y);
    }

    public static RigidbodyBehavior BuildRigidbodyBehavior(SpriteBehavior.ColliderType collider_type, string sprite_path = "", float x = 0, float y = 0)
    {
        return RigidbodyBehavior.InitializeRigidbodyBehavior(new GameObject().AddComponent<RigidbodyBehavior>(), collider_type, sprite_path, x, y);
    }

    public static PlayerBehavior BuildPlayerBehavior(float x = 0, float y = 0)
    {
        return PlayerBehavior.InitializePlayerBehavior(new GameObject().AddComponent<PlayerBehavior>(), x, y);
    }

    public static StemBehavior BuildStemBehavior (float x = 0, float y = 0)
    {
        return StemBehavior.InitializeStemBehavior(new GameObject().AddComponent<StemBehavior>(), x, y);
    }

    public static CarrotBehavior BuildCarrotBehavior(float x = 0, float y = 0)
    {
        return CarrotBehavior.InitializeCarrotBehavior(new GameObject().AddComponent<CarrotBehavior>(), x, y);
    }
    
}