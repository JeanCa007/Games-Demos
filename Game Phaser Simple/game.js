import Bootloader from './Bootloader.js';
import MainScene from './js/scenes/MainScene.js';
import Menu from './js/scenes/Menu.js';
import Win from './js/scenes/Win.js';
import UI from './js/scenes/UI.js';


//Configuración de la escena
var windows = {width:800,height: 480}
var config = {
    type: Phaser.AUTO,
    width: windows.width,
    height: windows.height,
    parent: "canvas",
    mode: Phaser.Scale.FIT,
    autoCenter: Phaser.Scale.CENTER_BOTH,
    scene: [
        Bootloader,
        UI,
        MainScene,
        Menu,
        Win
    ],
    physics: {
        default: 'arcade',
        arcade: {
            gravity: { y: 200 },
            //debug:true
        }
    }
};

var game = new Phaser.Game(config);


