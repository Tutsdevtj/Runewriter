# Runewriter

Runewriter é um jogo de ação e plataforma 2D feito em Unity e C#. Você atravessa masmorras, cavernas e pântanos, enfrenta inimigos e coleta runas para abrir caminho pelo cenário.

O combate tem combos e ataques aéreos, e a movimentação conta com pulo duplo, dash e deslize nas paredes. Entre uma luta e outra, as fogueiras permitem recuperar a vida.

## As runas

As runas fazem parte da progressão entre as áreas. Na sala de runas, a escolha no livro leva ao pântano ou à caverna: verde para o pântano, azul para a caverna. Reunir as duas cores permite liberar uma passagem bloqueada.

## Controles

| Ação | Tecla |
| --- | --- |
| Mover | A / D |
| Pular | Espaço |
| Pulo duplo | Espaço durante o salto |
| Dash | Shift ou C |
| Atacar | Botão esquerdo do mouse ou Z |
| Ataque aéreo | Atacar durante o salto |
| Interagir com altares, fogueiras e entradas | E |

## Rodando o projeto

O projeto usa **Unity 6000.0.49f1**. Para abrir na mesma versão:

1. Clone o repositório:

   ```bash
   git clone https://github.com/Tutsdevtj/Runewriter.git
   ```

2. No Unity Hub, adicione a pasta `Runewriter` como um projeto existente.
3. Abra com a versão indicada e aguarde a importação dos assets e pacotes.
4. Abra a cena `Assets/Scenes/MainMenu.unity` e pressione **Play**.

## Código

O comportamento do personagem e dos inimigos é separado em estados, como movimento, ataque, queda e morte. A base dessa máquina de estados fica em `Assets/Architecture/FSM`.

Os scripts do jogador estão em `Assets/Scripts/MCScripts`, os dos inimigos em `Assets/Enemies/Scripts` e a lógica das runas em `Assets/Scripts/Runes`. As cenas ficam em `Assets/Scenes`.

Além das ferramentas 2D da Unity, o projeto usa URP, Input System e Cinemachine.
