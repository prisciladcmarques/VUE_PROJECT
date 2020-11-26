<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Cod.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td>{{ professor.id }}</td>
          <td>{{ professor.nome }} {{ professor.sobrenone }}</td>
          <td>
            3
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum Aluno Encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      Professores: [
        { id: 1, nome: "Vinicius" },
        { id: 2, nome: "Paula" },
        { id: 3, nome: "Luna" },
      ],
    };
  },
};
</script>

<style lang="scss" scoped></style>
