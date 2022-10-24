// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_state_move(){
	
if(right)
{
	x = x+velocidad;
	
	h_dir = 1;
	
} else if(left)
{
	x = x-velocidad;
	h_dir = -1;
}else if(up)
{
	y = y-velocidad;
	
	
}else if(down)
{
	y = y+velocidad;
}

image_xscale = h_dir;
sprite_index = spr_batman_run;


if(!right && !left && !up && !down){
	
	state = scr_state_dle;
}


}