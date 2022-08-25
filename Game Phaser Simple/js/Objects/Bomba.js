class Bomba extends Phaser.Physics.Arcade.Sprite {
    constructor(scene,x,y) {
        super(scene,x,y,'bomba');
        this.scene = scene;
        this.scene.add.existing(this);
        this.scene.physics.add.existing(this);
        this.body.allowGravity = false;
        this.body.setBounce(0);
        this.body.setCircle(15);
        this.body.setVelocityX(0)
        this.body.setVelocityY(0);
    }

    followPlayer(player, bomba) {
        var angle = Math.atan2(player.y - bomba.body.y, player.x - bomba.body.x);
        this.body.velocity.x = Math.cos(angle) * 100;
        this.body.velocity.y = Math.sin(angle) * 100;

    }

    destruirBomba(bomba)
    {
        bomba.setVisible(false);
        bomba.body.destroy();
    }
}

export default Bomba;