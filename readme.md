## Projeto ##

Jogo desenvolvido de acordo com o curso [Aprenda a criar um jogo com Unity para Android](https://www.udemy.com/aprenda-a-criar-um-jogo-com-unity-para-android/) disponibilizado na **Udemy**. O jogo desenvolvido é um clone do famoso jogo casual **Timberman**.

Resolução: 1000 x 1400

## Anotações ##

* Para gráficos no estilo **pixel art**, deve-se colocar o **FilterMode** dos sprites para **Point**.

* Colisores só funcionam em objetos que possuam RigidBody.

* Usar o **Time.deltaTime** para trabalhar com tempo em segundos dentro do jogo.

### Size

A câmera ortográfica possui um campo chamado **size**. Ele define a área visível que parte do centro da tela até o topo em unidades unity (ou seja, metade da tela). Sendo que cada unidade unity corresponde a 1 metro. Uma câmera com unidade unity igual a 1, significa que a tela terá, em alturar, 2 unidades unity. Na altura, o Unity irá sempre mostrar a mesma quantidade de unidade unity independente da resolução. A largura sim pode variar de acordo com a resolução.

```
float screenHeightInUnits = Camera.main.orthographicSize * 2;
float screenWidthInUnits = screenHeightInUnits * Screen.width/ Screen.height; // basically height * screen aspect ratio
```

### Inverter lado 

Acessar o **Sprite Renderer** e alterar a propriedade **flipX** ou **flipY**.

### RigidBody2d sem cair ###

Setando a gravidade pro objeto como zero, ou definindo o **Body Type** como **Kinematic**.

### Body Type ###

* Static - O objeto para de reagir a gravidade ou a forças aplicadas de contatos de qualquer outro RigidBody. Em relação a colisão, só irá funcionar caso ele colida com um objeto de body type **Dynamic**. Ele também pode detectar colisões com objetos **Kinematic** se o check **Use Full Kinematic Controls** estiver verdadeiro. Se um **Collider2D** do tipo **trigger** estiver presente nesse objeto, sempre irá disparar ao encontrar objetos types Dynamic e Kinematic.

Esse objeto não deve se mover. Ele deve ser **ESTÁTICO**.

* Kinematic - O objeto para de reagir a gravidade ou a forças aplicadas de contatos de qualquer outro RigidBody Kinematic ou Static. Esse objeto só irá colidir com objetos Dynamic, exceto no caso do check **Use Full Kinematic Controls** estar verdadeiro, que irá habilitar a colisão para todos os tipos de objetos.