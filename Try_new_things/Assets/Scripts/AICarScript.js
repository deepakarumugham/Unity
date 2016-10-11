var path : Array;
var pathGroup : Transform;
var centerOfMass : Vector3;
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;

var currentPathObj : int;
var rb : Rigidbody;

var currentSpeed : float;
var topSpeed : float = 250;
var decellerationSpeed : float = 20;
var maxSteer : float = 15;
var distanceFromPath : float = 20;
var maxTorque : float = 100;


function Start () {
	rb = GetComponent.<Rigidbody>();
	rb.centerOfMass = centerOfMass;
    GetPath();
}

function GetPath(){
	var pathObjs : Array = pathGroup.GetComponentsInChildren(Transform);
	path = new Array();
	
	for(var pathObj : Transform in pathObjs ){
		if(pathObj != pathGroup){
		     path[path.length] = pathObj;
		}
	}

}

function Update () {
	Steer();
	Move();
}

function Steer(){
    var x = path[currentPathObj].position.x;
    var y = transform.position.y;
    var z = path[currentPathObj].position.z;
	var steerVector : Vector3 = transform.InverseTransformPoint(Vector3(x, y, z));
	Debug.Log("X: "+ x + " Y: " + y + " Z: " +z);
	Debug.Log("New X: "+ steerVector.x + " Y: " + steerVector.y + " Z: " + steerVector.z);
	var direction = (steerVector.x / steerVector.magnitude);
	var newSteer : float = maxSteer * direction;
	
	wheelFL.steerAngle = newSteer;
	wheelFR.steerAngle = newSteer;
	
	if(steerVector.magnitude <= distanceFromPath){
		currentPathObj++;
		if(currentPathObj >= path.length){
			currentPathObj = 0;
		}
	}

}


function Move(){
    currentSpeed = (2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 ) / 1000;
    currentSpeed = Mathf.Round(currentSpeed);
    Debug.Log("Current Speed: " + currentSpeed);
    /*if(currentSpeed <= topSpeed){*/
		wheelRL.motorTorque = maxTorque;
		wheelRR.motorTorque = maxTorque;
		/*wheelRL.brakeTorque = 0;
		wheelRR.brakeTorque = 0;
	}else{
		wheelRL.motorTorque = 0;
		wheelRR.motorTorque = 0;
		wheelRL.brakeTorque = decellerationSpeed;
		wheelRR.brakeTorque = decellerationSpeed;	
	}*/
	

}