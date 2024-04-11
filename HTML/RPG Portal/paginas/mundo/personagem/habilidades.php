<!DOCTYPE html>
<html lang="pt-br">

<head>

	<title>Portal</title>
	<script src="interacao/html5shiv.min.js"></script>
	<meta name="author" content="Marcelo Scalvi (14) 99101-4484">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<link rel="shortcut icon" href="../../../multimidia/logo.jpg">
	<link rel="stylesheet" type="text/css" href="../../../css/estilo.css"> 
		
</head>

<body>

<header>
	<figure id="cabeca">
		<img src="../../../multimidia/header.jpg">
	</figure>
</header>

<nav id="menu">
	<ul>
		<li><a href="../../../index.html">Home</a></li>
		<li><a href="../../../mundo-home.html">Mundo</a></li>
		<li><a href="../../../regras-home.html">Regras</a></li>
		<li><a href="../../../jogo-home.html">Jogar!</a></li>
	</ul>
</nav>

<main>
<div id="artigo">

	<h2>Habilidades</h2>
	
	<p><b>Aviso</b>: essa mensagem não é salva, copie para um arquivo separado.</p>

	<?php
		$poder = 0;
		$nivelpersonagem = 0;
		$categoria = isset($_POST["categoria"])?$_POST["categoria"]:"4";
		$tipo = isset($_POST["tipo"])?$_POST["tipo"]:"4";
		$alvos = isset($_POST["alvos"])?$_POST["alvos"]:"0";
		$area = isset($_POST["area"])?$_POST["area"]:"0";
		$formato = isset($_POST["formato"])?$_POST["formato"]:"0";
		$duracao = isset($_POST["duracao"])?$_POST["duracao"]:"0";
		$ativacao = isset($_POST["ativacao"])?$_POST["ativacao"]:"0";
		$cristal = isset($_POST["cristal"])?$_POST["cristal"]:"1";
		$nivel = isset($_POST["nivel"])?$_POST["nivel"]:"0";
		$nivelprof = isset($_POST["nivelprof"])?$_POST["nivelprof"]:"0";
		$custo = isset($_POST["custo"])?$_POST["custo"]:"0";
		$testesmeus = isset($_POST["testesmeus"])?$_POST["testesmeus"]:"0";
		$testesalvo = isset($_POST["testesalvo"])?$_POST["testesalvo"]:"0";
		$prof1 = isset($_POST["prof1"])?$_POST["prof1"]:"0";
		$prof2 = isset($_POST["prof2"])?$_POST["prof2"]:"0";
		$prof3 = isset($_POST["prof3"])?$_POST["prof3"]:"0";
		$dific1 = isset($_POST["dific1"])?$_POST["dific1"]:"0";
		$dific2 = isset($_POST["dific2"])?$_POST["dific2"]:"0";
		$dific3 = isset($_POST["dific3"])?$_POST["dific3"]:"0";
		$motivo1 = isset($_POST["motivo1"])?$_POST["motivo1"]:"0";
		$motivo2 = isset($_POST["motivo2"])?$_POST["motivo2"]:"0";
		$motivo3 = isset($_POST["motivo3"])?$_POST["motivo3"]:"0";
		$prof1i = isset($_POST["prof1i"])?$_POST["prof1i"]:"0";
		$prof2i = isset($_POST["prof2i"])?$_POST["prof2i"]:"0";
		$prof3i = isset($_POST["prof3i"])?$_POST["prof3i"]:"0";
		$dific1i = isset($_POST["dific1i"])?$_POST["dific1i"]:"0";
		$dific2i = isset($_POST["dific2i"])?$_POST["dific2i"]:"0";
		$dific3i = isset($_POST["dific3i"])?$_POST["dific3i"]:"0";
		$motivo1i = isset($_POST["motivo1i"])?$_POST["motivo1i"]:"0";
		$motivo2i = isset($_POST["motivo2i"])?$_POST["motivo2i"]:"0";
		$motivo3i = isset($_POST["motivo3i"])?$_POST["motivo3i"]:"0";
		
		$poder = $alvos + ($area * $formato) + $duracao + $ativacao;
		
		$nivelpersonagem = $nivel * $nivelprof;
		$nivelpersonagemmagico = $nivelprof * $cristal;
		
		if ($poder >= 10){
			$nivelpoder = "Alto";
		}
		else {
			$nivelpoder = "Baixo";
		}
			
		if ($nivelpersonagem >= 5){
			$nivelpoderpersonagem = "Alta";
		}
		else {
			$nivelpoderpersonagem = "Baixa";
		}	
		
		if ($nivelpersonagemmagico >= 5){
			$nivelpodermagico = "Alto";
		}
		else {
			$nivelpodermagico = "Baixo";
		}
		
		if ($categoria == 1){
			$categoriaescrito = "Magia";
			$recurso = "Mana";
		}
		else {
			if ($categoria == 0){
				$categoriaescrito = "Técnica";
				$recurso = "Estâmina";
			}
			else {
				$categoriaescrito = "Característica";
				$recurso = "Estâmina";
			}
		}
		
		if ($tipo == 1){
			$tipoescrito = "Ativa";
		}
		else {
			if ($tipo == 3){
				$tipoescrito = "Passiva";
			}
			else {
				$tipoescrito = "Reativa";
			}
		}
		
		if ($categoria == 1){
			if ($nivelpoder <= $nivelpodermagico){
				$custobal = $custo - $nivelpodermagico;
			}
			else {
				$custobal = $custo + $nivelpodermagico;
			}
		}
		else{
			if ($nivelpoder <= $nivelpoderpersonagem){
				$custobal = $custo - $nivelpoderpersonagem;
			}
			else {
				$custobal = $custo + $nivelpoderpersonagem;
			}
		}
	?>
	
	<h3>O que você fez:</h3>

	<p><b><?php echo ($_POST['nome']); ?></b></p> 
	<p><?php echo "$tipoescrito"; ?> - <?php echo "$categoriaescrito"; ?> - <?php echo $_POST['custo']; ?><?php echo " de $recurso"; ?></p>
	<p><?php echo $_POST['descricaosimples']; ?></p>
	<p><?php
		if ($testemeu == 0){
			echo "A habilidade não possui testes.";
		}
		else {
		if ($testemeu == 3){
			echo "Você faz um teste de $prof1, dificuldade $dific1, $motivo1.";
			echo "Você faz um teste de $prof2, dificuldade $dific2, $motivo2.";
			echo "Você faz um teste de $prof3, dificuldade $dific3, $motivo3.";
		}
		else {
		if ($testemeu ==2){
			echo "Você faz um teste de $prof1, dificuldade $dific1, $motivo1.";
			echo "Você faz um teste de $prof2, dificuldade $dific2, $motivo2.";	
		}
		else {
			echo "Você faz um teste de $prof1, dificuldade $dific1, $motivo1.";
		}
		}
		}
	?></p>	
	<p><?php
		if ($testealvo == 0){
			echo "A habilidade não possui testes para o inimigo.";
		}
		else {
		if ($testealvo == 3){
			echo "O alvo faz um teste $prof1i, dificuldade $dific1i, $motivo1i.";
			echo "O alvo faz um teste $prof2i, dificuldade $dific2i, $motivo2i.";
			echo "O alvo faz um teste $prof3i, dificuldade $dific3i, $motivo3i.";
		}
		else {
		if ($testealvo ==2){
			echo "O alvo faz um teste $prof1i, dificuldade $dific1i, $motivo1i.";
			echo "O alvo faz um teste $prof2i, dificuldade $dific2i, $motivo2i.";	
		}
		else {
			echo "O alvo faz um teste $prof1i, dificuldade $dific1i, $motivo1i.";
		}
		}
		}
	?></p>
	<p><?php echo "Avaliação: o poder é <b>$nivelpoder</b>, sendo que o poder mágico do personagem é <b>$nivelpodermagico</b> ou irrelevante, 
	e sua habilidade é <b>$nivelpoderpersonagem</b> ou irrelevante."; ?></p>
	
	<h3>Proposta de Balanceamento:</h3>

	<p><b><?php echo ($_POST['nome']); ?></b></p> 
	<p><?php echo "$tipoescrito"; ?> - <?php echo "$categoriaescrito"; ?> - <?php echo "$custobal de $recurso"; ?></p>
	<p><?php echo $_POST['descricaosimples']; ?></p>
	<p><?php
		if ($categoria == 1){
			if ($nivelpoder <= $nivelpodermagico){
				echo "A provavelmente está balanceada, sendo seu novo custo: $custobal.";
			}
			else {
				echo "Tente diminuir alguns pontos, como o número de alvos ou a duração, ou ainda aumentar o número de testes ou o
				tempo para conjuração.";
			}
		}
		else{
			if ($nivelpoder <= $nivelpoderpersonagem){
				echo "A provavelmente está balanceada, sendo seu novo custo: $custobal.";
			}
			else {
				echo "Tente diminuir alguns pontos, como o número de alvos ou a duração, ou ainda aumentar o número de testes ou o
				tempo para ativação.";
			}
		}
	?></p>

</main>
	
</body>

<footer id="rodape">
	<figure id="casa">
		<a href="geradordehabilidades.html"><img src="../../../multimidia/seta.png"></a>
	</figure>
</footer>

</html>