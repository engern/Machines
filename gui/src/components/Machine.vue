<template>
  <div class="machine">
    <h3>
      {{ machine.name }}
      <i @click="$emit('delete-machine', machine.id)" class="fas fa-times"></i>
      <i @click="$emit('edit-machine', machine.id)" class="fas fa-pen"></i>
    </h3>
  </div>
</template>

<script>
export default {
  name: 'Machine',
  props: {
    machine: Object,
  },
}
</script>

<style scope>
.fa-times {
  color: red;
}
.fas{
  cursor: pointer;
}
.machine {
  background: #f4f4f4;
  margin: 5px;
  padding: 10px 20px;
}

.machine h3 i {
  float:right;
  margin-left: 20px;
}
</style>