<script lang="ts">
	import App from "$lib/components/Game.svelte";
	import { scrollTo, openLink } from "$lib/navigation";
</script>

<svelte:head>
	<title>Swinburne Simulator</title>
</svelte:head>

<header id="main-menu">
	<h1>
		<img src="/logo.svg" alt="Swinburne Simulator" />
	</h1>
	<nav>
		<button class="wide" on:click={scrollTo("game")}>Start</button>
		<button class="wide" on:click={openLink("/about")}>About</button>
	</nav>
</header>

<main id="game">
	<button id="exit" on:click={scrollTo("main-menu")}>Exit</button>
	<App />
</main>

<style>
	header {
		width: 100vw;
		height: 100vh;
		padding: 1rem;
		background-color: #0005;
		align-content: center;
		text-align: center;
	}

	header h1 {
		margin-block: 0 1rem;
	}

	header img {
		width: 25em;
		height: auto;
	}

	header nav {
		margin: auto;
		width: fit-content;
		display: flex;
		flex-direction: column;
		gap: 1rem;
	}

	main {
		width: 100vw;
		height: 100vh;
		background: linear-gradient(skyblue 0%, lightblue 100%);
		position: relative;
	}

	button#exit {
		position: absolute;
		top: 1rem;
		left: 1rem;
	}
</style>
