/// @description Insert description here
// You can write your code in this editor
scr_get_input();



if(selected_option == 0){ //new game

	if(down_tap){
	
	selected_option = 1;
	
	}
	if(up_tap){
	
	selected_option = 0;
	
	}
	if(enter){
		
	room_goto_next();
	
	}
	
}else if(selected_option == 1){ //credtis

	if(down_tap){
	
	selected_option = 2;
	
	}
	if(up_tap){
	
	selected_option = 0;
	
	}
	
	if(enter){
		
	 instance_create_depth(0,0,-9999,obj_credits)
	
	}

}else if(selected_option == 2){ //exit

	if(down_tap){
	
	selected_option = 0;
	
	}
	if(up_tap){
	
	selected_option = 1;
	
	}
	
	if(enter){
		
	game_end();
	
	}

}