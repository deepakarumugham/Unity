var path : Array;
var rayColor : Color = Color.white;

function OnDrawGizmos(){
	Gizmos.color = rayColor;    
	var pathObjs : Array = transform.GetComponentsInChildren(Transform);
	path = new Array();
	
	for(var pathObj : Transform in pathObjs ){
		if(pathObj != transform){
		     path[path.length] = pathObj;
		}
	}
	
	for(var i : int = 0; i < path.length; i++){
		var current : Vector3 = path[i].position;
		if(i > 0){
			var previous = path[i - 1].position;
			Gizmos.DrawLine(previous, current);
			Gizmos.DrawWireSphere(current, 0.3f);
		}
	}
	
}