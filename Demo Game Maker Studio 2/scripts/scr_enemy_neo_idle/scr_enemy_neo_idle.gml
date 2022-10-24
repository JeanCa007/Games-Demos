// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_enemy_neo_idle(){
	
	
	var distance = distance_to_object(obj_player); //obtengo la  distancia entre dos objetos
	
	if(distance >= 150){
		
		var dir = point_direction(x,y,obj_player.x,obj_player.y); // guardo la ubicacion  de un objeto en base a otro objeto
		x = x  + lengthdir_x(2,dir); // le indico la velocidad y hace que punto X se debe mover
		y = y + lengthdir_y(2,dir);
		dir_x = sign(lengthdir_x(2,dir)); // calcula si memuevo a izquierda y derecha en base a la direcion X retorna 1 o -1
		image_xscale = dir_x;
		
		sprite_index = spr_enemy_move;
		
	}else{
		
		sprite_index = spr_enemy_neo_idle;
		if(alarm[0] <= 0){

			alarm[0] = room_speed*2; //tiempo se da de la velocidad de frame por 3 en este caso
		}
	}
	

}