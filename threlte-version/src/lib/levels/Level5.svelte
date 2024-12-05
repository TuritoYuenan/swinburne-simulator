<script lang="ts">
	import { T } from "@threlte/core";
	import { Materials } from "$lib/materials";
	import Elevator from "$lib/components/Elevator.svelte";
	import DoubleGlassDoor from "$lib/components/DoubleGlassDoor.svelte";
	import IndoorWindowedWall from "$lib/components/IndoorWindowedWall.svelte";
	import { BoxGeometry, Mesh } from "three";
</script>

<!-- Floor -->

<T.Mesh material={Materials.white} position={[-3.75, 0, -10]}>
	<T.BoxGeometry args={[19.5, 1, 10]} />
</T.Mesh>

<T.Mesh material={Materials.white} position={[0, 0, 11]}>
	<T.BoxGeometry args={[27, 1, 12]} />
</T.Mesh>

<T.Mesh material={Materials.white}>
	<T.BoxGeometry args={[12, 1, 10]} />
</T.Mesh>

<T.Mesh material={Materials.white} position={[9.75, 0, 0]}>
	<T.BoxGeometry args={[7.5, 1, 10]} />
</T.Mesh>

<T.Mesh material={Materials.white} position={[-7.5, 0, 0]}>
	<T.BoxGeometry args={[3, 1, 10]} />
</T.Mesh>

<!-- Walls -->

<IndoorWindowedWall material={Materials.cyan} position={[-5.9, 1, -3]} />
<IndoorWindowedWall material={Materials.cyan} position={[-5.9, 1, 3]} />
<DoubleGlassDoor position={[-5.9, 2, 0]} />
<DoubleGlassDoor position={[0, 2, 5.1]} rotation={Math.PI / 2} />

<T.Mesh material={Materials.glass} position={[-2.5, 2.5, -5.1]}>
	<T.BoxGeometry args={[7, 4, 0.01]} />
</T.Mesh>

<T.Mesh material={Materials.glass} position={[-3.5, 2.5, 5.1]}>
	<T.BoxGeometry args={[5, 4, 0.01]} />
</T.Mesh>

<T.Mesh material={Materials.glass} position={[3.5, 2.5, 5.1]}>
	<T.BoxGeometry args={[5, 4, 0.01]} />
</T.Mesh>

<T.Mesh material={Materials.cyan} position={[-9.65, 2.5, 5.1]}>
	<T.BoxGeometry args={[7.7, 4, 0.2]} />
</T.Mesh>

<T.Mesh material={Materials.cyan} position={[-13.4, 2.5, 11.1]}>
	<T.BoxGeometry args={[0.2, 4, 11.8]} />
</T.Mesh>

<T.Mesh material={Materials.green} position={[6.5, 2.5, 4.8]}>
	<T.BoxGeometry args={[1, 4, 0.6]} />
</T.Mesh>

<T.Mesh material={Materials.green} position={[6.5, 2.5, -4.5]}>
	<T.BoxGeometry args={[1, 4, 1]} />
</T.Mesh>

<!-- Hallway Walls -->

<T.Mesh material={Materials.cyan} position={[-7.5, 2.5, -4.9]}>
	<T.BoxGeometry args={[3, 4, 0.2]} />
</T.Mesh>

<T.Mesh material={Materials.cyan} position={[-7.5, 2.5, 4.9]}>
	<T.BoxGeometry args={[3, 4, 0.2]} />
</T.Mesh>

<T.Mesh material={Materials.yellow} position={[-13.4, 2, 0]}>
	<T.BoxGeometry args={[0.2, 5, 3]} />
</T.Mesh>

<!-- Elevator -->

<Elevator position={[-11.75, 0, 3.25]} />
<Elevator position={[-11.75, 0, -3.25]} />

<!-- Posts -->

<T.Mesh material={Materials.yellow} position={[-7.5, 2.5, -4.75]}>
	<T.BoxGeometry args={[1.5, 2, 0.1]} />
</T.Mesh>

<T.Mesh material={Materials.yellow} position={[-7.5, 2.5, 4.75]}>
	<T.BoxGeometry args={[1.5, 2, 0.1]} />
</T.Mesh>
