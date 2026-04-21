mergeInto(LibraryManager.library, {

	//SpeakWeb: function (strPointer, languageCodeStrPtr, speakRate) 
	SpeakWeb: function (strPointer, languageCodeStrPtr, rate) 
	{
		if (!navigator.userActivation.hasBeenActive) {
    		console.log("Tried to use SpeakWeb without user activation");
    		return;
  		}

		// Create JavaSCript string from Unity's string pointer
		var str = UTF8ToString(strPointer);
		var lang = UTF8ToString(languageCodeStrPtr);

		var msg = new SpeechSynthesisUtterance(str);
		msg.lang = lang; // 'en-US';
		msg.volume = 1; // 0 to 1
		msg.rate = rate;//speakRate; //1; // 0.1 to 10
		msg.pitch = 1.5; //0 to 2

		// Stop any TTS that may still be active
		window.speechSynthesis.cancel();

		window.speechSynthesis.speak(msg);
	},

	CancelSpeakWeb: function() 
	{
			window.speechSynthesis.cancel();
	},

	IsSpeakingWeb: function()	
	{
		return (window.speechSynthesis.speaking || window.speechSynthesis.pending);
	}
});
