<script lang="ts">
	import { T } from "@threlte/core";
	import { type Material } from "three";
	import { Materials } from "../materials";

	export let position: [number, number, number] = [0, 0, 0];
	export let material: Material = Materials.red;
</script>

<T.Group {material} {position}></T.Group>

<T.Mesh {material} position={[position[0], position[1] + 0.1, position[2]]}>
	<T.BoxGeometry args={[0.2, 1.2, 4]} />
</T.Mesh>

<T.Mesh
	{material}
	position={[position[0], position[1] + 1.7, position[2] + 1.75]}
>
	<T.BoxGeometry args={[0.2, 2, 0.5]} />
</T.Mesh>

<T.Mesh
	{material}
	position={[position[0], position[1] + 1.7, position[2] - 1.75]}
>
	<T.BoxGeometry args={[0.2, 2, 0.5]} />
</T.Mesh>

<T.Mesh
	material={Materials.glass}
	position={[position[0], position[1] + 1.7, position[2]]}
>
	<T.BoxGeometry args={[0.2, 2, 3]} />
</T.Mesh>

<T.Mesh {material} position={[position[0], position[1] + 3.1, position[2]]}>
	<T.BoxGeometry args={[0.2, 0.8, 4]} />
</T.Mesh>
