<script lang="ts">
	import { Canvas } from "@threlte/core";
	import { PerfMonitor } from "@threlte/extras";
	import { World } from "@threlte/rapier";
	import Scene from "./Scene.svelte";
</script>

<Canvas>
	<PerfMonitor anchorX={"right"} logsPerSecond={30} />
	<World>
		<Scene />
	</World>
</Canvas>
