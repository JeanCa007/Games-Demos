class Player extends Phaser.Physics.Arcade.Sprite
{
    constructor(scene,x,y)
    {
        super(scene,x,y,'player');
        this.scene = scene;
        this.scene.add.existing(this);
        this.scene.physics.add.existing(this);

        
        //caja de colision
        this.body.setSize(17, 52);
        this.body.setOffset(27, 20);
        

        this.addAnimations();

        this.hitDelay = false;
        
        this.cursor = this.scene.input.keyboard.createCursorKeys();

        this.life = 3;
        
    }

    update(time,delta)
    {   
        this.deadFall();

        this.resetPosition();
        
        if(this.cursor.left.isDown)
        {
            this.setVelocityX(-10*delta);
            
            this.setFlipX(true); 
        }
        else if(this.cursor.right.isDown)
        {
            this.setVelocityX(10*delta);
            this.setFlipX(false); 
        }
        else
        {
            //Parado
            this.setVelocityX(0);
        }

        if (this.cursor.space.isDown && this.body.onFloor()) {
            
            this.setVelocityY(-12*delta);
            
        }


        if(!this.body.onFloor())
            this.play('jump', true);
        else if(this.body.velocity.x != 0)
            this.play('walk', true);
        else
            this.play('idle', true);

      
        
    }

    addAnimations(){

        this.anims.create({
            key: 'walk',
            frames: this.scene.anims.generateFrameNames('sprites_jugador', { start: 1, end: 18, prefix: 'walk-' }),
            frameRate: 10,
            repeat: -1
        });
        this.anims.create({
            key: 'idle',
            frames: this.scene.anims.generateFrameNames('sprites_jugador', { start: 1, end: 4, prefix: 'idle-' }),
            frameRate: 10,
            repeat: -1
        });

        this.anims.create({
            key: 'jump',
            frames: this.scene.anims.generateFrameNames('sprites_jugador', { start: 1, end: 4, prefix: 'jump-' }),
            frameRate: 5,
            repeat: -1
        });
    }

    rockCollision(rock) {
        if(!this.hitDelay) {
            this.hitDelay = true;
            this.scene.sound.play('draw');
            this.body

            this.life--;
            this.scene.registry.events.emit('remove_life');

            if(this.life === 0) {
                this.scene.registry.events.emit('game_over');
            }
            
            this.setTint(0x1abc9c);
            this.scene.time.addEvent({
                delay: 600,
                callback: () => {
                    this.hitDelay = false;
                    this.clearTint();
                }
            });
        }
    }

    bombCollision() {
        if(!this.hitDelay) {
            this.hitDelay = true;
            this.scene.sound.play('draw');
            this.body

            this.life--;
            this.scene.registry.events.emit('remove_life');

            if(this.life === 0) {
                this.scene.registry.events.emit('game_over');
            }

            this.setTint(0x1abc9c);
            this.scene.time.addEvent({
                delay: 600,
                callback: () => {
                    this.hitDelay = false;
                    this.clearTint();
                }
            });
        }
    }

    deadFall(){

        if(this.y>480){
            this.scene.registry.events.emit('game_over');
        }
        
    }

    resetPosition(){

        if(this.x < 0){

            this.setX(10);

        }else if(this.x > 1100 ){

            this.setX(1090);
        }

    }

}

export default Player;