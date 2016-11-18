/*
 * Author(s): Isaiah Mann
 * Description: Animations that use Particle Effects (should be dynamically generated)
 */
using UnityEngine;

public interface IParticleAnimation : IAnimation {
	ParticleSystem Particles {get;}
}
