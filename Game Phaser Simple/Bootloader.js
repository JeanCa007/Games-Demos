class Bootloader extends Phaser.Scene {
    constructor() {
        super('Bootloader'); 
    }

   
    preload() {
        
        this.load.path = './res/';
        this.load.image([
        'Bg', 
        'Btn_Play', 
        'Btn_Menu',
        'Titulo', 
        'Castillo', 
        'Puerta', 
        'Win',
        'life',
        'rock',
        'bomba',
        'moneda',
        'lose'
        
    ]);

    this.load.image('tiles','Tileset.png');
    this.load.tilemapTiledJSON('map','Map.json');
    this.load.image('bg-1', 'sky.png');
    this.load.image('sea', 'sea.png');
    this.load.image('player', 'idle-1.png');
    
    this.load.atlas('sprites_jugador','player_anim/player_anim.png',
    'player_anim/player_anim_atlas.json');
    this.load.spritesheet('tilesSprites','Tileset.png',
    { frameWidth: 32, frameHeight: 32 });


        //audio
        this.load.audio('Sweet', 'Sweet.wav' );
        this.load.audio('Win', 'Win.mp3');
        this.load.audio('draw', 'draw.mp3');
        this.load.audio('pop', 'pop.mp3');

        //font
        this.load.image('font', 'font/font.png');
        this.load.json('fontData', 'font/font.json');


        this.load.on('complete', () => {

            const fontData = this.cache.json.get('fontData');
            this.cache.bitmapFont.add('pixelFont', Phaser.GameObjects.RetroFont.Parse(this, fontData));
           
            this.scene.start('Menu');
        });
    }
}
export default Bootloader;

