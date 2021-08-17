<template>
  <div :key="machine.id" v-for="machine in machines">
    <Machine
      @delete-machine="$emit('delete-machine', machine.id)"      
      :machine="machine"
    />
  </div>
</template>

<script>
import Machine from './Machine'
export default {
  name: 'Machines',
  props: {
    machines: Array,
  },
  components: {
    Machine,
  },
  emits: ['delete-machine'],
}
</script>