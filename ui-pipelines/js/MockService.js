var PipelineService =  {
	getPipeline: function(id) {
		return {
		  "pipelineLabel": "My First Pipeline",
		  "favorite": false,
		  "tags": ["development", "sales"],
		  "channels": ["Quick Base"],
		  "default": ""
		}
	},
	savePipeline: function (pipelineJson) {
		// Add the code here to call the API (or temporarily, just log pipelineJson to the console)
		
	}
}