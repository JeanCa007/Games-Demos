/// @description Insert description here
// You can write your code in this editor

if(file_exists("save_data.sav")){
	
	player_data = ds_map_secure_load("save_Data.sav");

}else{
	
	player_data = ds_map_create(); //creao las tabla DB
    ds_map_add(player_data,"hp",100); //agrego colunmnas y valores
}


