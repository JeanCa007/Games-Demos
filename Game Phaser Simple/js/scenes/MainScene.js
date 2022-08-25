import Player from '../Player/player.js';
import Seta from '../Objects/Seta.js';
import Bomba from '../Objects/Bomba.js';
import Moneda from '../Objects/Moneda.js';
import Rock from '../Objects/Rock.js';
import Puerta from '../Objects/Puerta.js';


class MainScene extends Phaser.Scene {
    constructor() {
        super({ key: 'MainScene' });
    }

    init() {
        console.log('Se ha iniciado la escena MainScene');
         this.scene.launch('UI');
    }

   
    create() {

        //**************************** Backgorund *************************
        var bg_1 = this.add.tileSprite(0, 0, 800 * 8, 480 * 4, 'bg-1');
        bg_1.fixedToCamera = true;
        this.add.image(1110,200,'Castillo').setScale(0.7);

        //**************************** PLAYER *************************
        this.player = new Player(this, 50, 100);


        //**************************** tILEMAP *************************
        var map = this.make.tilemap({ key: 'map' });
        var tiles = map.addTilesetImage('Plataformas', 'tiles');
        var layer2 = map.createLayer('Fondo', tiles, 0, 0);
        var layer = map.createLayer('Suelo', tiles, 0, 0);




        //enable collisions for every tile
        layer.setCollisionByExclusion(-1, true);
        this.physics.add.collider(this.player, layer);


        //**************************** Camara *************************
        this.cameras.main.setBounds(0, 0, map.widthInPixels, map.heightInPixels);
        this.cameras.main.startFollow(this.player);
        this.cameras.main.setBounds(0, 0, map.widthInPixels, map.heightInPixels);

        //**************************** OBJETOS*************************

        //puerta win
        this.puerta=new Puerta(this,1110,200);
        this.physics.add.collider(this.puerta, layer);
        this.physics.add.overlap(this.puerta, this.player, () => {

            this.puerta.win();
        });

        //obstaculos
        this.obstaculo1 = new Rock(this, 200, 100);
        this.obstaculo2 = new Rock(this, 465, 100);
        this.obstaculo3 = new Rock(this, 735, 100);
        this.obstaculo4 = new Rock(this, 925, 100);

        this.grupoObstaculos = [this.obstaculo1, this.obstaculo2, this.obstaculo3, this.obstaculo4];
        this.physics.add.collider(this.grupoObstaculos, layer);
        this.physics.add.overlap(this.player, this.grupoObstaculos, () => {
            this.player.rockCollision();
        });

        //enemigo
        this.bomba1 = new Bomba(this, 1000, 0);
        this.physics.add.overlap(this.bomba1, this.player, () => {
            this.player.bombCollision(this.bomba1);
            this.bomba1.destruirBomba(this.bomba1);
        });

        //monedas
        this.itemsGroup = new Moneda({
            physicsWorld: this.physics.world,
            scene: this
        });

        this.physics.add.overlap(this.itemsGroup, this.player, () => {
            this.sound.play('pop');
            this.registry.events.emit('update_points');
            this.itemsGroup.destroyItem();
        });

      

        this.objetos = map.getObjectLayer('objetos')['objects'];
        this.setas = [];
        for (var i = 0; i < this.objetos.length; ++i) {
            var obj = this.objetos[i];
            if (obj.gid == 115) // en mi caso la seta
            {
                var seta = new Seta(this, obj.x, obj.y);
                this.setas.push(seta);
                this.physics.add.overlap(seta, this.player, this.destoySeta(seta), null, this);
            }
        }




    }


    destoySeta(seta) {

        seta.destroy();

    }


    update(time, delta) {
        this.player.update(time, delta);
        this.bomba1.update(time, delta);
        this.bomba1.followPlayer(this.player, this.bomba1);

    }

}

export default MainScene;