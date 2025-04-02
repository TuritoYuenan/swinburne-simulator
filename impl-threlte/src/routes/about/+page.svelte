<script lang="ts">
	import { openLink } from "$lib/navigation";
</script>

<svelte:head>
	<title>About Swinburne Simulator</title>
</svelte:head>

<header>
	<img src="/logo.svg" alt="Swinburne Simulator" />
	<h1>The Swinburne Simulator Video Game</h1>
	<h3>By Turito Yuenan, a student of Swinburne Vietnam</h3>
</header>

<main>
	<article>
		<h2>About</h2>
		<p>
			This video game (or "virtual exhibition") simulates the Swinburne
			University of Technology campus in Ho Chi Minh City, Vietnam.
		</p>
		<p>
			The game was originally made in the Godot game engine, and now in
			Threlte, a SvelteKit framework integrated with the Three.js library.
		</p>

		<h2>Credits</h2>
	</article>
	<button class="wide" on:click={openLink("/#game")}>Play the game</button>
</main>

<style>
	header {
		padding: 1rem;
		color: white;
		background-color: #d33;
		text-align: center;
	}

	header img {
		width: 30em;
		height: auto;
		filter: drop-shadow(0 4px 5px black);
	}

	main {
		padding: 1rem;
		background-color: white;
	}

	article {
		width: min(70vw, 75ch);
		margin: 0 auto 2rem;
	}

	button {
		margin: auto;
		display: block;
		align-content: center;
	}
</style>
