mergeInto(LibraryManager.library, {
  aFunctionImplementedInJavaScriptLibraryFile: function(utf8String) {
    var jsString = UTF8ToString(utf8String);
    window.alert(jsString);
    aFunctionImplementedInHtmlFile(jsString);
    aFunctionImplementedInExternalJsFile(jsString);
  },

  jsBindingGemUniAPIFromUnity: function(){
    jsBindingGemUniAPI();
  },

  jsBindingOnLimitScoreFromUnity: function(score){
    jsBindingOnLimitScore(score);
  },

  jsBindingRequestSubmitFromUnity: function(){
    jsBindingRequestSubmit();
  },
});
