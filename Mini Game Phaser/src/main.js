import Bootloader from './Bootloader.js';

import Play from './scenes/Play.js';
import Menu from './scenes/Menu.js';
import UI from './scenes/UI.js';

const config = {
    title: "TOMato",
    version: "0.0.1",
    type: Phaser.AUTO,
    scale: {
        parent: "phaser_container",
        width: 640,
        height: 360,
        mode: Phaser.Scale.FIT,
        autoCenter: Phaser.Scale.CENTER_BOTH
    },
    pixelArt: true,
    physics: {
        default: "arcade",
        "arcade": {
            gravity: {
                y: 2000
            }
        }
    },
    scene: [
        Bootloader,
        UI,
        Play,
        Menu
    ]
};

new Phaser.Game(config);