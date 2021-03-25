package tech.getarrays.wordsapp.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import tech.getarrays.wordsapp.model.Word;

import java.util.Optional;

public interface WordRepo extends JpaRepository<Word, Long> {
    void deleteEmployeeById(Long id);

    Optional<Word> findEmployeeById(Long id);
}
