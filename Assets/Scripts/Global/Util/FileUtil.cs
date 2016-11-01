/*
 * Author(s): Isaiah Mann
 * Description: Assists in loading and saving persistent files
 */

using UnityEngine;
using System.Collections;
using System.IO;

public static class FileUtil {

	public static string FileText (string path) {
		return convertQuotationMarks(
			Resources.Load<TextAsset>(path).text
		);
	}

	// JSON only accepts the standard quotation marks
	private static string convertQuotationMarks (string original) {
		char[] characters = original.ToCharArray();
		for (int i = 0; i < characters.Length; i++) {
			if (isIncorrectQuotationMark(characters[i])) {
				characters[i] = correctQuoatationMark();
			}
		}

		return new string(characters);

	}

	static bool isIncorrectQuotationMark (char character) {
		return (int) character == 8220 ||
			(int) character == 8221;
	}

	static char correctQuoatationMark () {
		return '"';
	}

	public static void WriteStringToPath (string text, string path) {
		#if !UNITY_WEBPLAYER
			File.WriteAllText(path, text);
		#endif
	}

	public static void AppendStringToPath (string text, string path) {
		#if !UNITY_WEBPLAYER
			File.AppendAllText(path, text);
		#endif
	}

	public static bool FileExistsAtPath (string path) {
		return File.Exists(path);
	}
}
