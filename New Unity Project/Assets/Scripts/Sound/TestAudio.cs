using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore {

	namespace Audio {

		public class TestAudio : MonoBehaviour
		{
			public AudioController audioController;

			private bool initiatedTitleSong;
			private bool initiatedAmbientSong;

#region Unity Functions
#if UNITY_EDITOR
			private void Update(){
				//audioController.PlayAudio(AudioType.StartMenu);
				//audioController.StopAudio(AudioType.StartMenu);
				//audioController.RestartAudio(AudioType.StartMenu);
				//audioController.IsTrackPlaying(AudioType.StartMenu);

				if ( GameManager.instance.IsGameStateStartMenu() &&
				!initiatedTitleSong ) {

					initiatedTitleSong = true;
					audioController.PlayAudio(AudioType.StartMenu);
				}

				if ( GameManager.instance.IsGameStateStart() &&
				!initiatedAmbientSong ) {
					initiatedAmbientSong = true;
					audioController.PlayAudio(AudioType.Tranquil);
				}


			}
#endif
#endregion

		}
	}
}
