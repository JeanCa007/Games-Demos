/// @description Esto corre en cada frame
// Esto corre en cada frame

scr_get_input();
script_execute(state);

depth = -y

if(hp<=0){
audio_stop_sound(bgm_lights_out);
room_goto(RoomGameOver);
}

if(pause && !instance_exists(obj_pause)){
	
instance_create_depth(0,0,-9999,obj_pause);	
	
}


